using Microsoft.Expression.Encoder;
using Microsoft.Expression.Encoder.Profiles;
using MyVideoSite.Diagnostics.LogEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVideoSite.Server.EncoderLib
{
    public class Encoder
    {
        public MediaItem CreateMediaItem(string fileName)
        {
            MediaItem mediaItem;
            try
            {
                mediaItem = new MediaItem(fileName);
                AdvancedVC1VideoProfile profile = new AdvancedVC1VideoProfile();
                profile.SmoothStreaming = true;
                profile.AdaptiveGop = false;
                mediaItem.OutputFormat.VideoProfile = profile;
            }
            catch (Exception ex)
            {
                Logger.ReportFromException(ex);
                throw;
            }
            return mediaItem;
        }

        public string CreateAndExcuteEncodeJob(MediaItem mediaItem, string outputFolder)
        {
            try
            {
                using (Job job = new Job())
                {
                    job.MediaItems.Add(mediaItem);
                    job.OutputDirectory = outputFolder;
                    job.ApplyPreset(Presets.VC1IISSmoothStreamingSD480pVBR);

                    job.Encode();
                    return job.ActualOutputDirectory;
                }
            }
            catch (Exception ex)
            {
                Logger.ReportFromException(ex);
                throw;
            }
        }
    }
}
